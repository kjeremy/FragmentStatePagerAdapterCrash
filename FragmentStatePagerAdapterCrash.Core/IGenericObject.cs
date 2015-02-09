namespace FragmentStatePagerAdapterCrash.Core
{
    public interface IGenericObject
    {
        int Id { get; set; }
    }

    public class FirstGenericObject : IGenericObject
    {
        public int Id { get; set; }
        public string Random { get; set; }
    }

    public class SecondGenericObject : IGenericObject
    {
        public int Id { get; set; }
    }

    public class ThirdGenericObject : IGenericObject
    {
        public int Id { get; set; }
    }

    public class FourthGenericObject : IGenericObject
    {
        public int Id { get; set; }
    }

    public class FifthGenericObject : IGenericObject
    {
        public int Id { get; set; }
    }
}
