using System;

namespace ConsoleApp4
{
  /// <summary>

  /// MainApp startup class for Real-World 

  /// Observer Design Pattern.

  /// </summary>

  class MainApp

  {
    /// <summary>

    /// Entry point into console application.

    /// </summary>

    static void Main()
    {
      // Create IBM stock and attach investors

      IBM ibm = new IBM("IBM", 120.00);
      ibm.Attach(new Investor("Sorros"));
      ibm.Attach(new Investor("Berkshire"));
 
      // Fluctuating prices will notify investors

      ibm.Price = 120.10;
      ibm.Price = 121.00;
      ibm.Price = 120.50;
      ibm.Price = 120.75;
 
      // Wait for user

      Console.ReadKey();
    }
  }

  /// <summary>

  /// The 'ConcreteSubject' class
  ///
  /// Store state of interest to ConcreteObserver
  /// Sends a notification to its observers when its state changes

  /// </summary>


  class IBM : Stock

  {
    // Constructor

    public IBM(string symbol, double price)
      : base(symbol, price)
    {
    }
  }
 
 
  /// <summary>

  /// The 'ConcreteObserver' class

  /// </summary>

  class Investor : IInvestor

  {
    private string _name;
    private Stock _stock;
 
    // Constructor

    public Investor(string name)
    {
      this._name = name;
    }
 
    public void Update(Stock stock)
    {
      Console.WriteLine("Notified {0} of {1}'s " +
        "change to {2:C}", _name, stock.Symbol, stock.Price);
    }
 
    // Gets or sets the stock

    public Stock Stock
    {
      get { return _stock; }
      set { _stock = value; }
    }
  }
}