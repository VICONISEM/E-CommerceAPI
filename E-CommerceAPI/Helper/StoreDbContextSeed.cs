using Store.DAL.Contexts;
using Store.DAL.Entities;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace E_CommerceAPI.Helper
{
    public class StoreDbContextSeed
    {
        public static async Task SeedAsync(StoreDbcontext storeDbcontext,ILoggerFactory loggerFactory)
        {

            try { 

                if (storeDbcontext.ProductTypes != null && !storeDbcontext.ProductTypes.Any())
                {
                    var TypesData = File.ReadAllText("D:\\ASP.NET\\ROUTE\\02 C#\\C_Sharp_route_assingment\\E-CommerceAPI\\E-CommerceAPI\\Helper\\DataSeed\\ProductType.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    if (Types is not null)
                    {
                        await storeDbcontext.ProductTypes.AddRangeAsync(Types);
                        await storeDbcontext.SaveChangesAsync();
                    }
                }



                if (storeDbcontext.ProductBrands != null && !storeDbcontext.ProductBrands.Any())
                {
                    var BrandData = File.ReadAllText("D:\\ASP.NET\\ROUTE\\02 C#\\C_Sharp_route_assingment\\E-CommerceAPI\\E-CommerceAPI\\Helper\\DataSeed\\ProductBrand.json");
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandData);
                    if (Brands is not null)
                    {
                        await storeDbcontext.ProductBrands.AddRangeAsync(Brands);
                        await storeDbcontext.SaveChangesAsync();

                    }

                }



              

             

                if (storeDbcontext.Products != null && ! storeDbcontext.Products.Any())
                {
                    var ProductData = File.ReadAllText("D:\\ASP.NET\\ROUTE\\02 C#\\C_Sharp_route_assingment\\E-CommerceAPI\\E-CommerceAPI\\Helper\\DataSeed\\Product.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    if (Products is not null)
                    {
                        await storeDbcontext.Products.AddRangeAsync(Products);
                    }
                }


                await storeDbcontext.SaveChangesAsync();

            
            }
            catch(Exception ex) {

                var logger = loggerFactory.CreateLogger<StoreDbcontext>();
                logger.LogError(ex.Message);
            
            }

        }
    }
}
