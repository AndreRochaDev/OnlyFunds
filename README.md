# Component.Middleware.Whitelist

This component adds a middleware to the pipeline that prevents access  
to endpoints (except Swagger) if the request ip is not whitelisted

## How to use

Add this to your service collection <br>

    services.AddWhitelist(configuration)  


Add this to your application builder <br>

    app.UseWhitelist()  

In your configuration you should add the following id and secret information:

    "Component": {  
      "Whitelist": {  
		"ClientId": "Id",  
		"ClientSecret": "Secret"  
      }  
    }


## Releases

0.0.1 - Initial Commit

## Contributing
To contribute to this package or report a bug, please inform the Funds Composable team or the following dudes:<br>  
<andre.almeida-rocha@axians.com>  <br>  
<andre.rodrigues@axians.com>