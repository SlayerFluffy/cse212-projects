using System.Collections;
using System.Diagnostics;
using System.Dynamic;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: make a queue with 0 length, then one with 15, then make one with 5
        // Expected Result: first queue should default to 10, then 15, then 5
        Console.WriteLine("Test 1");
        var customers = new CustomerService(0);
        string customersString = customers.ToString();
        Console.WriteLine(customersString);

        customers = new CustomerService(15);
        customersString = customers.ToString();
        Console.WriteLine(customersString);

        customers = new CustomerService(5);
        customersString = customers.ToString();
        Console.WriteLine(customersString);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add customers to queue until max reached.
        // Expected Result: Should alert when too many customers added, then show list of customers
        Console.WriteLine("Test 2");

        customers = new CustomerService(3);
        customers.AddNewCustomer();
        customers.AddNewCustomer();
        customers.AddNewCustomer();
        customers.AddNewCustomer();
        string cusString = customers.ToString();
        Console.WriteLine(customers);

        // Defect(s) Found: Size of queue was saving one size larger than entered.

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: test dequeue
        // Expected Result: Should be able to dequeue the next customer and display the details. Once empty, error message.
        Console.WriteLine("Test 3");

        customers.ServeCustomer();
        customers.ServeCustomer();
        customers.ServeCustomer();
        customers.ServeCustomer();

        // Defect(s) Found: It was removing customers before saving them to a variable to be accessed and displayed.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("Customer Queue is empty.");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}