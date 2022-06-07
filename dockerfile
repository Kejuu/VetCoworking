FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore "VetCoworking/App/VetCoworking.App.csproj" 
RUN dotnet publish "VetCoworking/App/VetCoworking.App.csproj"

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build-env /app/ .

ENTRYPOINT ["dotnet", "VetCoworking.App.dll"]
