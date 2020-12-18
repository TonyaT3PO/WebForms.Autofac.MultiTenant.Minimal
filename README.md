# WebForms.Autofac.MultiTenant.Minimal
I tried my best to mimic what I would need to do in the real world for an existing multitenant webforms app that I want to add Autofac and Entity Framework to. The Entity Framework DbContext will need to use the tenant connection string, which is what Database.cs mimicks.

The application has two tenants, each with their own sub-directory. Each tenant directory has a page with a user control to display tenant specific data.

You might need to run the following if you get an error at run time about “Could not find a part of the path '...WebForms.Autofac.MultiTenant.Web\bin\roslyn\csc.exe'”
>Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

[https://stackoverflow.com/questions/32780315/could-not-find-a-part-of-the-path-bin-roslyn-csc-exe](https://stackoverflow.com/questions/32780315/could-not-find-a-part-of-the-path-bin-roslyn-csc-exe)

After running the application, click on Tenant1 and Tenant2 to see the data change for each tenant.
