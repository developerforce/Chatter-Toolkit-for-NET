# Chatter Toolkit for .NET <img src="http://dfbuild.cloudapp.net/app/rest/builds/buildType:ChatterToolkitForNet_DebugCiBuild/statusIcon" />

The Chatter Toolkit for .NET provides an easy way for .NET developers to interact with the Chatter REST API using a native libraries. This toolkit is built using the [Async/Await pattern](http://msdn.microsoft.com/en-us/library/hh191443.aspx) for asynchronous development and .NET [portable class libraries](http://msdn.microsoft.com/en-us/library/gg597391.aspx), making it easy to target multiple Microsoft platforms, including .NET 4/4.5, Windows Phone 8, Windows 8/8.1, and Silverlight 5.

## NuGet Packages

### Published Packages

You can try the library immmediately by installing this [NuGet package](http://www.nuget.org/packages/DeveloperForce.Chatter/).

```
Install-Package DeveloperForce.Chatter
```

### DevTest Packages

If you want to use the most recent DevTest NuGet packages you can grab the packages built during the CI build. All you need to do is setup Visual Studio to pull from the build servers NuGet feed:

1. In Visual Studios select **Tools** -> **Library Package Manager** -> **Package Manager Settings**. Choose **Package Sources**.
2. Click **+** to add a new source.
3. Change the **Name** to "Salesforce Toolkits for .NET (DevTest)".
4. Change the **Source** to http://dfbuild.cloudapp.net/guestAuth/app/nuget/v1/FeedService.svc/.

Now you can choose to install the latest NuGet from this DevTest feed.

## Samples

The toolkit includes the following sample applications.

TBD

## Operations

Currently the following operations are supported.

### Authentication

To access the Force.com APIs you must have a valid Access Token. Currently there are two ways to generate an Access Token: the [Username-Password Authentication Flow](http://help.salesforce.com/HTViewHelpDoc?id=remoteaccess_oauth_username_password_flow.htm&language=en_US) and the [Web Server Authentication Flow](http://help.salesforce.com/apex/HTViewHelpDoc?id=remoteaccess_oauth_web_server_flow.htm&language=en_US)

#### Username-Password Authentication Flow

The Username-Password Authentication Flow is a straightforward way to get an access token. Simply provide your consumer key, consumer secret, username, and password.

```
var auth = new AuthenticationClient();

await auth.UsernamePasswordAsync("YOURCONSUMERKEY", "YOURCONSUMERSECRET", "YOURUSERNAME", "YOURPASSWORD");
```

#### Web-Server Authentication Flow

The Web-Server Authentication Flow requires a few additional steps but has the advantage of allowing you to authenticate your users and let them interact with the Force.com using their own access token.

First, you need to authetnicate your user. You can do this by creating a URL that directs the user to the Salesforce authentication service. You'll pass along some key information, including your consumer key (which identifies your Connected App) and a callback URL to your service.

```
var url =
    Common.FormatAuthUrl(
        "https://login.salesforce.com/services/oauth2/authorize", // if using test org then replace login with text
        ResponseTypes.Code,
        "YOURCONSUMERKEY",
        HttpUtility.UrlEncode("YOURCALLBACKURL"));
```

After the user logs in you'll need to handle the callback and retrieve the code that is returned. Using this code, you can then request an access token.

```
await auth.WebServerAsync("YOURCONSUMERKEY", "YOURCONSUMERSECRET", "YOURCALLBACKURL", code);
```

You can see a demonstration of this in the following sample application: https://github.com/developerforce/Force.com-Toolkit-for-NET/tree/master/samples/WebServerOAuthFlow

#### Creating the ChatterClient

After this completes successfully you will receive a valid Access Token and Instance URL. The Instance URL returned identifies the web service URL you'll use to call the Force.com REST APIs, passing in the Access Token. Additionally, the authentication client will return the API version number, which is used to construct a valid HTTP request.

Using this information, we can now construct our Force.com client.

````
var instanceUrl = auth.InstanceUrl;
var accessToken = auth.AccessToken;
var apiVersion = auth.ApiVersion;

var client = new ChatterClient(instanceUrl, accessToken, apiVersion);
```

### Sample Code

Below you'll find a few examples that show how to use the toolkit.

#### Get Information About Yourself

You can grab your personal feed with the following code:

```
var me = await chatter.MeAsync<Me>();
```

#### Post to Your Feed

You can easily post to your Chatter feed with the following code:

```
var me = await chatter.MeAsync<Me>();
var id = me.id;

var messageSegment = new MessageSegment()
{
    text = "Testing 1, 2, 3",
    type = "Text"
};

var body = new FeedItemBody { messageSegments = new List<MessageSegment> { messageSegment } };
var feedItemInput = new FeedItemInput()
{
    attachment = null,
    body = body
};

var feedItem = await chatter.PostFeedItemAsync<FeedItem>(feedItemInput, id);
```

#### Comment on a Feed

You can comment on a Chatter feed with the following code:

```
var feedId = feedItem.id;

var messageSegment = new MessageSegment()
{
    text = "Comment testing 1, 2, 3",
    type = "Text"
};

var body = new FeedItemBody { messageSegments = new List<MessageSegment> { messageSegment } };
var commentInput = new FeedItemInput()
{
    attachment = null,
    body = body
};

var comment = await chatter.PostFeedItemCommentAsync<Comment>(commentInput, feedId);
```

#### Like a Feed

You can like a Chatter feed with the following code:

```
var feedId = feedItem.id;

var liked = await chatter.LikeFeedItemAsync<Liked>(feedId);
```
