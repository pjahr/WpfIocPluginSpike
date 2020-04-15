using PublicApi;
using System;
using System.ComponentModel.Composition;
using System.Windows;

[Export]
public partial class PluginResources : ResourceDictionary, IResourceDictionary
{
    public Uri Uri { get; } = ExternalResourceDictionaryUri.Create<PluginResources>();
}
