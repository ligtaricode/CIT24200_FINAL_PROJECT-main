// CustomerRepositoryTests.cs

[TestClass]
public class CustomerRepositoryTests
{
    private readonly Mock<NorthwindContext> _mockContext;
    private readonly ICustomerRepository _repository;

    public CustomerRepositoryTests()
    {
        _mockContext = new Mock<NorthwindContext>();
        _repository = new CustomerRepository(_mockContext.Object);
    }

    [TestMethod]
    public void GetCustomers_ReturnsAllCustomers()
    {
        // Arrange
        var customers = new List<Customer>
        {
            new Customer { CustomerID = "ALFKI", ContactName = "Maria Anders" },
            new Customer { CustomerID = "ANATR", ContactName = "Ana Trujillo" },
            new Customer { CustomerID = "ANTON", ContactName = "Antonio Moreno" }
        };
        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.AsQueryable().Provider);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.AsQueryable().Expression);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.AsQueryable().ElementType);
        mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => customers.AsQueryable().GetEnumerator());
        _mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

        // Act
        var result = _repository.GetCustomers();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customers.Count, result.Count());
        CollectionAssert.AreEqual(customers, result.ToList());
    }

    [TestMethod]
    public void GetCustomer_ValidId_ReturnsCustomer()
    {
        // Arrange
        var customer = new Customer { CustomerID = "ALFKI", ContactName = "Maria Anders" };
        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.Setup(m => m.Find(customer.CustomerID)).Returns(customer);
        _mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

        // Act
        var result = _repository.GetCustomer(customer.CustomerID);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(customer, result);
    }

    [TestMethod]
    public void GetCustomer_InvalidId_ReturnsNull()
    {
        // Arrange
        var mockSet = new Mock<DbSet<Customer>>();
        mockSet.Setup(m => m.Find(It.IsAny<string>())).Returns<Customer>(null);
        _mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

        // Act
        var result = _repository.GetCustomer("invalid id");

        // Assert
        Assert.IsNull(result);
    }
}


// OrderRepositoryTests.cs

[TestClass]
public class OrderRepositoryTests
{
    private readonly Mock<NorthwindContext> _mockContext;
    private readonly IOrderRepository _repository;

    public OrderRepositoryTests()
    {
        _mockContext = new Mock<NorthwindContext>();
        _repository = new OrderRepository(_mockContext.Object);
    }

    [TestMethod]
    public void GetOrders_ReturnsAllOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerID = "ALFKI", OrderDate = new DateTime(2022, 1, 1) },
            new Order { OrderID = 2, CustomerID = "ANATR", OrderDate = new DateTime(2022, 1, 2) },
            new Order { OrderID = 3, CustomerID = "ANTON", OrderDate = new
