namespace TJS.VIMS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VIMSDBContext context;

        public UnitOfWork(VIMSDBContext context)
        {
            this.context = context;
           
        }
        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}