using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TheBox_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {


        public List<Product> FindAll()
        {

            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {

                return theBoxEntities.ProductEntities.Select(p => new Product
                {
                    ID_Product = p.ID_Product,
                    ID_Provider = p.ID_Provider,
                    ID_ProductCategory = p.ID_ProductCategory,
                    TX_Name = p.TX_Name,
                    TX_Description = p.TX_Description,
                    NU_Price = p.NU_Price,
                    NU_ShippingCost = p.NU_ShippingCost,
                    BO_SpecialOffer = p.BO_SpecialOffer,
                    BO_Service = p.BO_Service,
                    BO_Active = p.BO_Active
                }).ToList();
            }
        }

        public Product Find(string id)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                long nid = Convert.ToInt64(id);
                return theBoxEntities.ProductEntities.Where(p => p.ID_Product == nid).Select(p => new Product
                {
                    ID_Product = p.ID_Product,
                    ID_Provider = p.ID_Provider,
                    ID_ProductCategory = p.ID_ProductCategory,
                    TX_Name = p.TX_Name,
                    TX_Description = p.TX_Description,
                    NU_Price = p.NU_Price,
                    NU_ShippingCost = p.NU_ShippingCost,
                    BO_SpecialOffer = p.BO_SpecialOffer,
                    BO_Service = p.BO_Service,
                    BO_Active = p.BO_Active,
                    IM_Image = p.IM_Image
                }).FirstOrDefault();
            }
        }

        public ResponseOperation Create(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Product product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }


        public string[] FindProductNames(RequestTheBoxApp requestTheBoxApp)
        {

            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {
                ObjectResult<string> names = (theBoxEntities.GetProductNamesByText(requestTheBoxApp.Text));

                return names.ToArray();
            }
        }




        //public List<Product> FindProductByLocation(RequestTheBoxApp requestTheBoxApp)
        //{
        //    using (TheBoxEntities theBoxEntities = new TheBoxEntities())
        //    {
        //        ObjectResult<ProductEntity> products = (theBoxEntities.SP_GetProductsByLocation(requestTheBoxApp.Text, requestTheBoxApp.Latitud, requestTheBoxApp.Longitud));
        //        List<Product> productos = products.Select(p => new Product
        //        {
        //            ID_Product = p.ID_Product,
        //            ID_Provider = p.ID_Provider,
        //            ID_ProductCategory = p.ID_ProductCategory,
        //            TX_Name = p.TX_Name,
        //            TX_Description = p.TX_Description,
        //            NU_Price = p.NU_Price,
        //            NU_ShippingCost = p.NU_ShippingCost,
        //            BO_SpecialOffer = p.BO_SpecialOffer,
        //            BO_Service = p.BO_Service,
        //            BO_Active = p.BO_Active
        //        }).ToList();
        //        return productos;
        //    }
        //}
        public ProductProvider FindProductByLocation(RequestTheBoxApp requestTheBoxApp)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {

                var db = theBoxEntities;
                //Database db = theBoxEntities.Database;
                db.Database.Initialize(force: false);

                // Create a SQL command to execute the sproc vic
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC [dbo].[SP_GetProductsByLocation] '" + requestTheBoxApp.Text + "'," + requestTheBoxApp.Latitud.ToString().Replace(",", ".") + "," + requestTheBoxApp.Longitud.ToString().Replace(",", ".") + "," + requestTheBoxApp.ID_Provider;

                db.Database.Connection.Open();
                // Run the sproc  
                var reader = cmd.ExecuteReader();

                ProductProvider lista = new ProductProvider();

                // Read Blogs from the first result set 
                var products = ((IObjectContextAdapter)db)
                    .ObjectContext
                    .Translate<Product>(reader, "ProductEntities", MergeOption.AppendOnly);

                lista.products = products.ToList();

                reader.NextResult();
                var providers = ((IObjectContextAdapter)db)
                    .ObjectContext
                    .Translate<Provider>(reader, "ProviderEntities", MergeOption.AppendOnly);

                lista.providers = providers.ToList();


                //ObjectResult<ProductEntity> products = (theBoxEntities.SP_GetProductsByLocation(requestTheBoxApp.Text, requestTheBoxApp.Latitud, requestTheBoxApp.Longitud));
                //List<Product> productos = products.Select(p => new Product
                //{
                //    ID_Product = p.ID_Product,
                //    ID_Provider = p.ID_Provider,
                //    ID_ProductCategory = p.ID_ProductCategory,
                //    TX_Name = p.TX_Name,
                //    TX_Description = p.TX_Description,
                //    NU_Price = p.NU_Price,
                //    NU_ShippingCost = p.NU_ShippingCost,
                //    BO_SpecialOffer = p.BO_SpecialOffer,
                //    BO_Service = p.BO_Service,
                //    BO_Active = p.BO_Active
                //}).ToList();
                return lista;
            }
        }
        public ProductProvider FindSpecialOffersByLocation(RequestTheBoxApp requestTheBoxApp)
        {
            using (TheBoxEntities theBoxEntities = new TheBoxEntities())
            {

                var db = theBoxEntities;
                //Database db = theBoxEntities.Database;
                db.Database.Initialize(force: false);

                // Create a SQL command to execute the sproc vic
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC [dbo].[SP_GetSpecialOffersByLocation] '" + requestTheBoxApp.Text + "'," + requestTheBoxApp.Latitud.ToString().Replace(",", ".") + "," + requestTheBoxApp.Longitud.ToString().Replace(",", ".");

                db.Database.Connection.Open();
                // Run the sproc  
                var reader = cmd.ExecuteReader();

                ProductProvider lista = new ProductProvider();

                // Read Blogs from the first result set 
                var products = ((IObjectContextAdapter)db)
                    .ObjectContext
                    .Translate<Product>(reader, "ProductEntities", MergeOption.AppendOnly);

                lista.products = products.ToList();

                reader.NextResult();
                var providers = ((IObjectContextAdapter)db)
                    .ObjectContext
                    .Translate<Provider>(reader, "ProviderEntities", MergeOption.AppendOnly);

                lista.providers = providers.ToList();


                //ObjectResult<ProductEntity> products = (theBoxEntities.SP_GetProductsByLocation(requestTheBoxApp.Text, requestTheBoxApp.Latitud, requestTheBoxApp.Longitud));
                //List<Product> productos = products.Select(p => new Product
                //{
                //    ID_Product = p.ID_Product,
                //    ID_Provider = p.ID_Provider,
                //    ID_ProductCategory = p.ID_ProductCategory,
                //    TX_Name = p.TX_Name,
                //    TX_Description = p.TX_Description,
                //    NU_Price = p.NU_Price,
                //    NU_ShippingCost = p.NU_ShippingCost,
                //    BO_SpecialOffer = p.BO_SpecialOffer,
                //    BO_Service = p.BO_Service,
                //    BO_Active = p.BO_Active
                //}).ToList();
                return lista;
            }
        }
    }
}
