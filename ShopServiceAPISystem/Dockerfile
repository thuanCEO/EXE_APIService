# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShopServiceAPISystem/ShopServiceAPISystem.csproj", "ShopServiceAPISystem/"]
RUN dotnet restore "ShopServiceAPISystem/ShopServiceAPISystem.csproj"
COPY . .
WORKDIR "/src/ShopServiceAPISystem"
RUN dotnet build "ShopServiceAPISystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopServiceAPISystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopServiceAPISystem.dll"]
