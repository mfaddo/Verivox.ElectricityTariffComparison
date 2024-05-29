# Verivox.ElectricityTariffComparison
This project is a platform for comparing electricity prices, where users can estimate their annual costs based on consumption. The project includes a RESTful service that retrieves electricity tariffs from an external provider, calculates the annual costs based on consumption, and returns the results to the user.

# Features
<li>Retrieve electricity tariffs from an external provider.</li>
<li>Calculate annual costs based on consumption for different tariff types.</li>
<li>Compare tariffs and return results sorted by costs in ascending order.</li>
<li>Expose the functionality through a RESTful API.</li>

# Installation
## Prerequisites
<li>.NET SDK (version 6.0 or later) installed on your machine.</li>
<br/>
<strong>Clone the Repository</strong>
<br/>

```
https://github.com/mfaddo/Verivox.ElectricityTariffComparison.git
```
<strong>Restore NuGet Packages</strong>
```
dotnet restore
```

<strong>Build the Project</strong>
```
dotnet build
```

<strong>Linux Installation Script</strong>
```
#!/bin/bash

# Update package lists
sudo apt-get update

# Install .NET SDK
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0

# Navigate to the project directory
cd Verivox.ElectricityTariffComparison

# Restore NuGet packages
dotnet restore

# Run the application
dotnet run --project Verivox.ElectricityTariffComparison

```

<strong>Make sure to give execute permissions to the script</strong>

```
chmod +x install_and_run.sh
```

The application will start and listen for requests at http://localhost:5219


# Usage
## API Endpoints

<li>GET /api/tariffs?consumption={consumption}: Retrieve tariff comparison results based on the specified consumption in kWh per year.
</li>

## Example
To get tariff comparison results for a consumption of 4500 kWh per year, you can make the following request:

```
GET http://localhost:5219/api/tariffs?consumption=4500

```


# Testing

## Unit Tests
Unit tests are implemented using NUnit and Moq. To run the tests, execute the following command:

```
dotnet test
```
