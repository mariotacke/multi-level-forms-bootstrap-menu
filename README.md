# Multi-Level Forms Bootstrap Menu
Multi-Level Forms Bootstrap Menu is here to bring the beauty of Bootstrap to ASP.NET's `Menu` control. 

Runs in IE 8+, Chrome, and Firefox

## Usage
First, register your assembly and include the CSS file in your project:
```html
<%@ Register tagPrefix="bootmenu" assembly="MultiLevelFormsBootstrapMenu" namespace="MultiLevelFormsBootstrapMenu" %>
...
<head>
  ...
  <link href="multilevelformsbootstrapmenu.css" rel="stylesheet" />
</head>
...
```
Then, create or modify your existing `Menu` control
```html    
<asp:Menu runat="server" DataSourceID="siteMap"></asp:Menu>
```
becomes
```html
<bootmenu:BootstrapMenu runat="server" DataSourceID="siteMap"></bootmenu:BootstrapMenu>
```    
## Dependencies

- .NET Framework 4.5 
- Bootstrap 3+
 
## Background and References
This project is an extension to [Jeremy Knight](jeremyknight.wordpress.com)'s [FormsBootstrapMenu](https://codelibrary.codeplex.com/SourceControl/latest#Main/Source/DL.Core.Web/Controls/BootstrapMenu.cs) with added sub menu CSS and modified markup generator.
