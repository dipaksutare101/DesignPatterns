using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddleLayer;
using Unity;
using InterfaceCustomer;
using Unity.Injection;
using InterfaceDAL;
using ADODotNetDAL;
using CommanDAL;
using Unity.Resolution;

namespace FactoryDALLayer
{
    /* On Next day- Factory is not Generic So, Make it Generic */
    public static class FactoryDAL<AnyType>
    {
        /* This Factory CL Created for Object Creation for UI
        So We can decouple Ui from Concrit Class like Customer , Lead */


        /* i am commect dictionaty collection because we have ready made object Creation library*/

        //private static Dictionary<string, CustomerBase> Cust = new Dictionary<string, CustomerBase>();
        private static IUnityContainer ObjectList = null;
       
        public static AnyType Create(string type)
        {

            /*  Ready made Solution for Object Creations */

            if (ObjectList == null)
            {
                ObjectList = new UnityContainer();

                ObjectList.RegisterType<IDAL<CustomerBase>, CustomerDAL>("AdoDal");
                 

            }


            return ObjectList.Resolve<AnyType>(type, new Unity.Resolution.ResolverOverride[]
                                                                                        {
                                                                                          new ParameterOverride("_Connectionstring",@"Data Source=DIPAK\SQLEXPRESS;Initial Catalog=DesignPattern;Persist Security Info=True;User ID=sa;Password=smart@123")
                                                                                        }
                                                                                    );

            /* In Constructor dictinary Fill again again it will create Performance issue ..Remove From Constructor */
            /* We need to use Lazy Loading Pattern -  Mean Load on Demand*/ //Design Pattern :-Lazy Loading Pattern 
                                                                            //if (Cust.Count==0)
                                                                            //{
                                                                            //    Cust.Add("Customer", new Customer());
                                                                            //    Cust.Add("Lead", new Lead());
                                                                            //}


            /* during  polymorphism lot if Condition used for different objects*/
            /* So, use RIP Pattern -  Replace of IF Polymerphism  */
            /* So, use RIP Pattern -  with Dictionary Collection  */ //Design Pattern :-RIP Pattern 
                                                                     //return Cust[type];




            /*  if create Object with if Condition (polymorphism)then lot of condition we need to apply for different different objects
             How to Remove if condition using dictionary Collection*/  /*  Design Pattern :- Factory Pattern*/
                                                                       /*  We using polymorphism which is act different in different conditions  */
                                                                       //if(type=="Lead")
                                                                       //{
                                                                       //    return new Lead();
                                                                       //}
                                                                       //else
                                                                       //{
                                                                       //    return new Customer();
                                                                       //}
        }
    }
}
