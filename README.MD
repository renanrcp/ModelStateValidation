# ModelStateValidation

<p align="center">
	</br>
	<a href="https://github.com/renanrcp/ModelStateValidation/actions">
		<img src="https://img.shields.io/github/workflow/status/renanrcp/ModelStateValidation/.NET%20Core?label=BUILD%20STATUS&logo=github&style=for-the-badge&logoWidth=20&labelColor=0d0d0d" />
	</a>
	<a href="https://www.nuget.org/packages/ModelStateValidation/">
		<img src="https://img.shields.io/nuget/v/ModelStateValidation.svg?label=Version&logo=nuget&style=for-the-badge&logoWidth=20&labelColor=0d0d0d" />
	</a>
	<a href="https://www.nuget.org/packages/ModelStateValidation/">
		<img src="https://img.shields.io/nuget/dt/ModelStateValidation.svg?label=Downloads&logo=nuget&style=for-the-badge&logoWidth=20&labelColor=0d0d0d" />
	</a>
    <a href="https://github.com/renanrcp/ModelStateValidation/blob/master/LICENSE">
		<img src="https://img.shields.io/badge/License-MIT-yellow.svg?label=License&style=for-the-badge&logoWidth=20&labelColor=0d0d0d" />
	</a>
    <p align="center">
        The ASP.NET Core Model State Validator fully abstracted to use in any .NET Core application.
    </p>
	<p align="center">
		This lib allows you to use the ASP.NET Core Model 	State Validator in any .NET Core project.
	</p>
</p>

# Warning

Don't use this for ASP.NET Core MVC and ASP.NET Core Webapi projects you probably don't need that for these projects that already has this validation type implemented with the IObjectModelValidator, this lib will probably have no conflict if you inject in the dependency container.

# Installation

You can add this lib via nuget package manager.

Dotnet cli example:

```bash
dotnet add package ModelStateValidation
```

# Implementation

You can use this lib as a static class or with the IServiceProvider dependendency container.

## Dependency Injection

### Setup

Inject this lib in your IServiceCollection like that:

```cs
IServiceCollection services = new ServiceCollection();

services.AddModelStateValidation();
```

Equals to ASP.NET Core you can pass configurations for this with an action:

```cs
IServiceCollection services = new ServiceCollection();

services.AddModelStateValidation(options =>
{
   options.MaxModelValidationErrors = 200;
});
```

### Usage

For use this, just get the IModelStateValidator from the dependency provider like that:

```cs
var validator = provider.GetService<IModelStateValidator>();

// Pass the object to be valitaded and it will return true if is valid.
var isValid = validator.TryValidateModel(model);
```

Obs: any service injected in dependency container can get this service in your constructor.

## Static use

Not every project has dependency injection, so this lib supports static usage:

```cs
var isvalid = ModelStateValidator.TryValidateModel(model);
```

## Validation overloads

You can decide if you'll pass a ModelStateDictionary a model name prefix or no.

See this example with a ModelStateDictionary and a empty prefix:

```cs
var modelState = new ModelStateDictionary(200);
var prefix = string.Empty;

var isValid = validator.TryValidateModel(model, modelState, prefix);

// Here all overloads:
isValid = validator.TryValidateModel(model);
isValid = validator.TryValidateModel(model, modelState);
isValid = validator.TryValidateModel(model, prefix);
isValid = validator.TryValidateModel(model, modelState, prefix);
```

# License

This project uses the [MIT License](https://github.com/renanrcp/ModelStateValidation/blob/master/LICENSE).
