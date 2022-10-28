# HouseMovingAssistant

This is an app that was shown during Luce Carter's talk at .NET Conf: Focus on MAUI event. The idea behind it is to show you how you might approach certain features and interacting with Realm and Atlas App Services on MongoDB's multi-cloud Developer Data Platform.

## Running it yourself

If you wish to run this app yourself, make sure to update it with your own Realm-AppId. You can find this in the dashboard of your Atlas App Services application. 

In order to make it work, you will need to have some backend functionality configured in App Services including a trigger for when a new user is created and a function for creating users in a Users collection for logging in and data storage/partitioning.

If you want to learn how to make a App Services + Xamarin/MAUI app from scratch, the best tutorial to follow can be found on [our website](https://www.mongodb.com/docs/atlas/app-services/tutorial/dotnet/).

However, if you wish to continue to running this yourself, there are two files in this repo that you will need to apply to your own Atlas App Services app for this.

### Functions

You will need to have a few functions configured in your backend. Access Functions inside App Services for your app you have created to run this (so the same one as where you got your appID) and add new functions with the same names as the file names(without the .md file extension) you will find in [Backend-Samples](./Backend-Samples/). The contents of each file can then be copied and pasted into these new functions to replace the boilerplate code. After saving the function code inside the Function Editor, ensure you switch to the Settings tab and select Authentication as System.

### Triggers

Now we have the functions set up to bring all the pieces together for handling users in the application. We now want to set up a Trigger inside App Services that will get triggered when the Create Account button is clicked on the Login Page to call our new createUserDocument function.

Access Triggers from the left side menu in App Services and create a new Trigger called onNewUser with the folowing details:

- Trigger Type: Authentication
- Name: onNewUser
- Enabled: yes
- Action Type: Create
- Providers: Email/Password
- Select an Event Type: Function
- Function: createNewUserDocument





