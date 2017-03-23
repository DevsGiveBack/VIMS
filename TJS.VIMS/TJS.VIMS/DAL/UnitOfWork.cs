namespace TJS.VIMS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VIMSDBContext _context;

        public UnitOfWork(VIMSDBContext context)
        {
            _context = context;
           
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}