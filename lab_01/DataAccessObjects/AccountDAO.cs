using BusinessObjects;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string accountId)
        {
            using var db = new MyStoreDbContext();
            return db.AccountMembers.FirstOrDefault(c => c.MemberId.Equals(accountId));
        }
        public static AccountMember GetAccountByEmail(string email)
        {
            using (var context = new MyStoreDbContext())
            {
                return context.AccountMembers
                    .SingleOrDefault(a => a.EmailAddress.ToLower() == email.ToLower());
            }
        }
    }
}
