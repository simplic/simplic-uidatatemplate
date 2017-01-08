# simplic-uidatatemplate
Contains a set of libraries to make your application customizable using wpf datatemplates.

## How to use the simplic ui templating system

### Include XAML-Namespace

All required xaml namespaces can be included using the following url:

```xml
xmlns:template="http://schemas.simplic-systems.com/2016/xaml/presentation"
```

Using it in a WPF window could look like this:

```xml
<Window x:Class="Sample.UIDataTemplate.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"

        xmlns:template="http://schemas.simplic-systems.com/2016/xaml/presentation"

        Title="MainWindow" Height="350" Width="525">

        <!-- ... ... ... -->
</Window>
```

### Getting started with a simple template

#### Setup an UIContentPresenter

The following sample shows, how to define an area which will be filled with a template:

```xml
<template:UIContentPresenter DataTemplateName="Sample01DataTemplate" x:Name="sampleContentTemplate" 

</template:UIContentPresenter>
```

This is an empty content presenter which can be filled with pre defined templates or templates that
are loaded at runtime.

#### Add UITemplates

To be able to show a datatemplate that gets presented, we need to define it in the list of templates:

```xml
<template:UIContentPresenter DataTemplateName="Sample01DataTemplate" x:Name="sampleContentTemplate" 
    <template:UIContentPresenter.Templates>
        <template:UITemplate TemplatePath="SampleDataTemplate.xaml" />
    </template:UIContentPresenter.Templates>
</template:UIContentPresenter>
```

#### Add UITemplates using Selector

#### Add a template loader

#### Add a dynamic template resolver

#### Add a custom UITemplate Selector

#### Add a template editor

### Creator and contributor

* [Simplic GmbH](https://simplic.biz)