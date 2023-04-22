namespace Northwind.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly NorthwindContext _context;

    public CustomerRepository(NorthwindContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.ToList();
    }

    public Customer GetById(string id)
    {
        return _context.Customers.FirstOrDefault(c => c.CustomerId == id);
    }
}
