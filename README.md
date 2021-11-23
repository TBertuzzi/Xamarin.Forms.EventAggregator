# Xamarin.Forms.EventAggregator

The EventAggregator provides multicast publish/subscribe functionality. This means there can be multiple publishers that raise the same event and there can be multiple subscribers listening to the same event.

###### This is the component, works on iOS, Android and UWP.

![](https://github.com/TBertuzzi/Xamarin.Forms.EventAggregator/blob/master/Resources/eventAggregator.png?raw=true)

![](https://github.com/TBertuzzi/Xamarin.Forms.EventAggregator/blob/master/Resources/aggregator.gif?raw=true)

**NuGet**

|Name|Info|
| ------------------- | :------------------: |
|Xamarin.Forms.EventAggregator|[![NuGet](https://buildstats.info/nuget/Xamarin.Forms.EventAggregator)](https://www.nuget.org/packages/Xamarin.Forms.EventAggregator/)|

*Platform Support**

Xamarin.Forms.EventAggregator is a .NET Standard 2.0 library.Its only dependency is the Xamarin.Forms

## Setup / Usage

Does not require additional configuration. Just install the package in the shared project and use.

**Sample**

Create a Sample Message

```csharp
    public class TextMessage
    {
        public string Text { get; set; }
    }
```

Register Handler to listen to the event

```csharp

  private void TextHandler(
    TextMessage message)
        {
            Text = message.Text;
        }
        
   //Register Event Handler
            EventAggregator.Instance.RegisterHandler<TextMessage>(
       TextHandler);
```

Send Message 

```csharp
   //Register Event
          
EventAggregator.Instance.SendMessage(TextMessage);
```


The complete example can be downloaded here: https://github.com/TBertuzzi/Xamarin.Forms.EventAggregator/tree/master/XamarinFormsEventAggregatorSample
