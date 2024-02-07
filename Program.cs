namespace Example_Decorator
{
    public interface ICar   // providing concrete implementation of Car
    {
        string GetDescription();
    }

    public class Car : ICar   // basic car or default car 
    {

        public string GetDescription()
        {
            // Console.WriteLine("Base Car");
            return "Mercedes";
        }
    }


    // concrete decorador class that provide derived class to implement the GetDescription() method to add more behavior
    // this class need to implement the Icar(component's interface) to get the _car object that refered to the based component, 
    // so each decorator class that extends from the CarDecorator class can get the based component object to decorate.

    public abstract class CarDecorator : ICar
    {
        protected ICar _car;
        public CarDecorator(ICar car)
        {
            _car = car;
        }

        // virtual here enable derived(child) class to override this method
        public virtual string GetDescription()
        {
            return _car.GetDescription();// here returning description of the based class.
        }
    }





    public class TireDecorator(ICar car) : CarDecorator(car) // here is called primary constructor

    {
        // override the base class
        public override string GetDescription()
        {
            string desc = base.GetDescription();
            return $"{desc}, With huge tire";// add more description here
        }
    }


    public class PaintDecorator : CarDecorator
    {
        public PaintDecorator(ICar car) : base(car) { }

        public override string GetDescription()
        {
            string desc = base.GetDescription();
            return $"{desc}, and blue exterior color...";
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new Car();

            Console.WriteLine(car.GetDescription()); // Mercedes

            ICar carWithDecoratedTire = new TireDecorator(car);

            Console.WriteLine(carWithDecoratedTire.GetDescription()); //Mercedes, With huge tire
            ICar blueCar = new PaintDecorator(car);

            Console.WriteLine(blueCar.GetDescription());//Mercedes, and blue exterior color...
        }
    }
}