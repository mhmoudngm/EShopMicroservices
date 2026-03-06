using Catalog.API.Models;
using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Catalog.API.Models.Product>().AnyAsync())
                return;


            session.Store<Catalog.API.Models.Product>(initialproducts());
            await session.SaveChangesAsync();
        }
        private List<Catalog.API.Models.Product> initialproducts()
        {
            return new List<Models.Product>()
            {
                new Models.Product()
                {
                      Name="initial Name",
                      Description="initial Description",
                      Imagefile= "initial Imagefile",
                      Price= 1000,
                      Category= new List<string>(){
                      "initial category1"}
                },
                 new Models.Product()
                {
                      Name="initial Name2",
                      Description="initial Description2",
                      Imagefile= "initial Imagefile2",
                      Price= 1000,
                      Category= new List<string>(){
                      "initial category2"}
                },
            };
        }
    }
}
