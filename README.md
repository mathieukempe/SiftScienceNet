SiftScienceNet
==============

SiftScienceNet is a .NET class library that provides an easy-to-use interface for the  [SiftScience](https://siftscience.com) SiftScience web api. 


####Sending events to Siftscience

```csharp

var response = siftClient.CreateOrder(new Order
               {
                   Amount = 1000000,
                   BillingAddress = new Address
                   {
                       Address1 = "190 Mulhouse street",
                       Address2 = "Unit 5",
                       City = "Sydney",
                       Country = "AU",
                       FullName = "Mathieu Kempe",
                       Region = "NSW",
                       ZipCode = "2021"
                   },
                   ShippingAddress = new Address
                   {
                       Address1 = "address1",
                       Address2 = "address2",
                       City = "Sydney",
                       Country = "AU",
                       FullName = "Mathieu kempe",
                       Region = "NSW",
                       ZipCode = "2021"
                   },
                   CurrencyCode = "USD",
                   Items = new List<Item>
                       {
                          new Item
                            {
                                Category = "digital",
                                CurrencyCode = "USD",
                                Tags = new List<string> { "tag1", "tag2", "tag3" },
                                Quantity = 4,
                                Brand = "brand",
                                Color = "red",
                                Isbn = "isbn",
                                ItemId = "12334",
                                Manufacturer = "rebok",
                                Price = 100000000,
                                ProductTitle = "Some product",
                                Size = "Large",
                                Sku = "V4C3D5R2Z6",
                                Upc = "654321",                                                        
                            }
                       },
                   UserId = "mathieukempe@gmail.com",
                   UserEmail = "mathieukempe@somemail.com",
                   OrderId = "12234",
                   SellerUserId = "4", 
                   ExpeditedShipping = false,                                            
                   PaymentMethods = new List<PaymentMethod>{new PaymentMethod
                                                                    {
                                                                        CardBin = "123456",
                                                                        CardLast4 = "1234",                                                                                                
                                                                        PaymentType = PaymentType.CreditCard
                                                                    }},

               });


```
