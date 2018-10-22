namespace basic.Common
{
    public class InheritMemberAccessDemoBaseClass
    {
        public InheritMemberAccessDemoBaseClass()
        {
            PublicProperty = "Public Property Value";
            ProtectedProperty = "Protected Property Value";
            PrivateProperty = "Protected Property Value";
        }

        public string PublicProperty { get; set; }

        protected string ProtectedProperty { get; set; }

        string PrivateProperty { get; set; }
    }

    public class InheritMemberAccessDemoClass : InheritMemberAccessDemoBaseClass
    {
        public string ManipulateProtectedMember()
        {
            return "The value is " + ProtectedProperty;
        }
    }
}