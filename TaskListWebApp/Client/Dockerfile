#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TaskListWebApp/Client/TaskListWebApp.Client.csproj", "TaskListWebApp/Client/"]
COPY ["TaskListWebApp/Shared/TaskListWebApp.Shared.csproj", "TaskListWebApp/Shared/"]
RUN dotnet restore "TaskListWebApp/Client/TaskListWebApp.Client.csproj"
COPY . .
WORKDIR "/src/TaskListWebApp/Client"
RUN dotnet build "TaskListWebApp.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskListWebApp.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskListWebApp.Client.dll"]