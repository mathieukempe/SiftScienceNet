SiftScienceNet
==============

SiftScienceNet is a .NET class library that provides an easy-to-use async interface for the  [SiftScience](https://siftscience.com) SiftScience web api. 

##Initializing

```csharp

SiftScienceClient siftClient = new SiftScienceClient("<Your Api key>");

```

Than to create an events

```csharp

var response = await client.CreateOrder(new Order
    {
        ...
    });

```



##Sending events to Siftscience

[SiftScience events api](https://siftscience.com/docs/references/events-api)

###Create Order

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

               }).Result;


```

###Transaction

```csharp

var response = siftClient.Transaction(new Transaction
               {
                   Amount = 100.ToMicros(),
                   BillingAddress = new Address
                   {
                       Address1 = "312 Mulhouse street",
                       Address2 = "Unit 123",
                       City = "Sydney",
                       Country = "AU",
                       FullName = "Mathieu kempe",
                       Region = "NSW",
                       ZipCode = "2021"
                   },
                   CurrencyCode = "AUD",
                   UserId = "1",
                   OrderId = "234423",
                   SessionId = "u4ryixmnkwxm1aviiyq4yez1",
                   ShippingAddress = new Address
                   {
                       Address1 = "312 Mulhouse street",
                       Address2 = "Unit 123",
                       City = "Sydney",
                       Country = "AU",
                       FullName = "Mathieu kempe",
                       Region = "NSW",
                       ZipCode = "2021"
                   },
                   PaymentMethod = new PaymentMethod
                                       {
                                           CardBin = "123456",
                                           CardLast4 = "1234",
                                           PaymentType = PaymentType.CreditCard,
                                           AvsResultCode = "T",
                                           PaymentGateway = PaymentGateway.Paypal,
                                       },
                   Status = TransactionStatus.Success,
                   TransactionType = TransactionType.Capture,
                   UserEmail = "mathieukempe@somemail.com",
                   TransactionId = "234423"
               }).Result;

```

###Create account

```csharp

siftClient.CreateAccount(new Account
                         {
                             UserId = "1",
                             UserEmail = "mathieu@selz.com",
                             SessionId = "54f3ds25423523gfdsgf4gfds",
                             Name = "Mathieu Kempe",
                             SocialSignOn = SocialSignOn.Facebook,
                             BillingAddress = new Address
                                 {
                                     City = "Mulhouse",
                                     Country = "FR"
                                 }
                         }).Result;

```

###Update account

```csharp

siftClient.UpdateAccount(new Account
			            {
			                UserId = "1",
			                UserEmail = "mathieukempe@somemail.com",
			                SessionId = "54f3ds25423523gfdsgf4gfds",
			                Name = "Mathieu Kempe",
			                BillingAddress = new Address
			                                     {
			                                         Address1 = "address1",
			                                         Address2 = "address2",
			                                         City = "Sydney",
			                                         Country = "AU",
			                                         FullName = "Mathieu kempe",
			                                         Region = "NSW",
			                                         ZipCode = "2021"
			                                     },
			                ChangedPassword = true
			
			            }).Result;

```

###Add item to cart

```csharp

siftClient.AddItemToCart("1",new Item
            {
                Category = "digital",
                CurrencyCode = "USD",
                Tags = new List<string> { "tag1", "tag2", "tag3" },
                Quantity = 4,
                Brand = "brand",
                Color = "red",
                Isbn = "isbn",
                ItemId = "12334",
                Manufacturer = "reebok",
                Price = 100000000,
                ProductTitle = "Some product",                
                Size = "Large",
                Sku = "2342",
                Upc = "234423",                
            },"54f3ds25423523gfdsgf4gfds").Result;
```

###Remove item from cart
```csharp

 siftClient.RemoveItemToCart("1", new Item
            {
                Category = "digital",
                CurrencyCode = "USD",
                Tags = new List<string> { "tag1", "tag2", "tag3" },
                Quantity = 4,
                Brand = "brand",
                Color = "red",
                Isbn = "isbn",
                ItemId = "12334",
                Manufacturer = "reybok",
                Price = 100000000,
                ProductTitle = "Some product",               
                Size = "Large",
                Sku = "2342",
                Upc = "234423",                
            },1,"54f3ds25423523gfdsgf4gfds").Result;

```

###Send message

```csharp

siftClient.SendMessage("1", "4", "some subject", "hello ").Result;

```

###Login (Success)

```csharp

siftClient.Login("1", "u4ryixmnkwxm1aviiyq4yez1", true).Result;

```

###Login (Failure)

```csharp

siftClient.Login("1", "u4ryixmnkwxm1aviiyq4yez1", false).Result;

```

###Logout

```csharp

siftClient.Logout("1").Result;

```

###Link user to session

```csharp

siftClient.LinkSessionToUser("1", "u4ryixmnkwxm1aviiyq4yez1").Result;

```


##Label users in Siftscience

[SiftScience labels api](https://siftscience.com/docs/references/labels-api/)


```csharp

siftClient.Label("1", true, new List<Reason> { Reason.Chargeback, Reason.Funneling }).Result;

```

##User score from Siftscience

[SiftScience scores api](https://siftscience.com/docs/getting-scores/)

```csharp

ScoreResponse scoreResponse = siftClient.GetSiftScore("1").Result;

```

##Sending Historical data

[SiftScience sending historical data](https://siftscience.com/docs/tutorials/sending-historical-data/)

Order, Transaction and Account have a Time property

```csharp
  var response = siftClient.CreateOrder(new Order
            	{
				Time = DateTime.Now.AddDays(-4).ToUnixTime()
				...

```
