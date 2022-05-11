#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Home Automation/Home Automation.csproj", "Home Automation/"]
RUN dotnet restore "Home Automation/Home Automation.csproj"
COPY . .
WORKDIR "/src/Home Automation"
RUN dotnet build "Home Automation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Home Automation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Home Automation.dll"]