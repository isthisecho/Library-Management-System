namespace LibraryManagementSystem.Abstractions
{
    public interface IUser
    {

        public string   FirstName                     { get; set; }
        public string   LastName                      { get; set; }
        public string   Email                         { get; set; }

        public IEnumerable<ITransaction> Transactions { get; set; }

    }
}
