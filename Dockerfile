# Use the .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the solution file and restore dependencies
COPY YourProject/YourProject.sln ./
COPY src/Services ./Services

# Restore dependencies
WORKDIR /app/Services/YourProject
RUN dotnet restore YourProject.Api/YourProject.Api.csproj

# Build and publish the API project
RUN dotnet publish YourProject.Api/YourProject.Api.csproj -c Release -o /publish

# Use the .NET 8 runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish .

# Expose ports
EXPOSE 5000
EXPOSE 5001

# Set entry point
ENTRYPOINT ["dotnet", "YourProject.Api.dll"]