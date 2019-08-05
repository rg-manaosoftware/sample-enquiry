# SampleEnquiry

An assingment about software architech technical  
DDD architech base on [https://github.com/GregTrevellick/Sample.Enquiry](https://github.com/GregTrevellick/Sample.Enquiry)


# Software requirement

- [ASP.NET COR 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [EntityFramwork](https://docs.microsoft.com/en-us/ef/core/)
- Database what you want, change connection string following EF rule

## Before start
Go to root_of_project and execute following command  
- ```dotnet restore```

## Database populate
Go to root_of_project/src/Sample.Enquiry.Api  
Update appseting.json with your SQL DB stuff  
Then go to  root_of_project/src/Sample.Enquiry.Infrastructure and execute following command  
- ```dotnet ef --startup-project ../Sample.Enquiry.Api migrations add init```
- ```dotnet ef --startup-project ../Sample.Enquiry.Api database update```

## Run
Go to root_of_project/src/Sample.Enquiry.Api and execute following command  
- ```dotnet run```  
Open Browser following information from ```dotnet run``` and click ```Populate data``` if you want

# Test
Go to root_of_project and execute following command  
- ```dotnet test```