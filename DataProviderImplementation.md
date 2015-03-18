# Introduction #

This BugtraqPlugin supports easy integration of 3rd party providers. Just implement and interface, update configuration and you're done


# Details #

BugtraqPluginContracts.dll contains a simple interface to implement to provide data for BugtraqPlugin.
```
public interface IDataProvider : IDisposable
{
   ReadOnlyIssueCollection Issues { get; }

   void Load();
}
```

Implement that interface, put your assembly into the BugtraqPlugin install path (usually located at _%ProgramFiles%\BugtraqPlugin_ and update configuration file BugtraqPlugin.dll.config as follows:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
 <configSections>
  <section name="microkernel" type="..." />
 </configSections>

 <microkernel>
  <typeAliases>
   <typeAlias alias="IDataProvider" type="BugtraqPlugin.Contracts.IDataProvider, BugtraqPluginContracts" />
   <!-- could add type alias here -->
   <typeAlias alias="[ProviderAliasName]" type="[FullQualifiedTypeName]" />
  </typeAliases>
  <containers>
   <container>
    <types>
     <!-- leave other providers and add your own below -->
     <type name="[YourProviderName]" type="IDataProvider" mapTo="[ProviderAliasType] or [FullQualifiedTypeName]" />
    </types>
   </container>
  </containers>
 </microkernel>
</configuration>
```

**Note that the name of the provider have to be distinct.**