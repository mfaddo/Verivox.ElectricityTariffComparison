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
dotnet run