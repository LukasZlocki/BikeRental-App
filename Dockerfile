#Dockerfile for BikeRental api
# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-new

# Set the working directory to /app
WORKDIR /app

# Copy the solution file and restore dependencies
COPY BikeRental.Api.sln .
COPY BikeRental.Api/BikeRental.Api.csproj ./BikeRental.Api/
COPY BikeRental.Models/BikeRental.Models.csproj ./BikeRental.Models/
COPY BikeRental.Services/BikeRental.Services.csproj ./BikeRental.Services/

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the application code
COPY BikeRental.Api/ ./BikeRental.Api/
COPY BikeRental.Models/ ./BikeRental.Models/
COPY BikeRental.Services/ ./BikeRental.Services/

# Build the application
RUN dotnet build -c Release -o out

# Create the runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-final
WORKDIR /app
COPY --from=build-new /app/out .

# Expose port 5000 for the application
EXPOSE 80
#EXPOSE 443

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "BikeRental.Api.dll"]