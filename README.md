# spacex-proxy-api
Technical Assesment for Software Engineer role at Heidelberg Materials.

# Config
After cloning, Open the SpaceXProxyAPI/SpaceXProxyAPI.sln file and navigate to SpaceXProxyAPI/appsettings.json. Paste the Url of the React App in this format to allow Cross Origin Request. (These settings are already there, you just need to update the Url if you have to).
"AllowedDomains": {
    "Urls": [
      "http://localhost:3000"
    ]
}

# Running
Build the API Project, Set this project as startup and run this project by pressing F11 or simply by run button in visual studio.

# Testing
Open the SpaceXProxyAPI.Test Project and navigate to SpaceXProxyAPI.Test/LaunchProxyAPITest.cs. There you can run individual tests or all tests in test explorer.
