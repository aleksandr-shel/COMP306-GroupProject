#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Group33_COMP306_GroupProject/Group33_COMP306_GroupProject.csproj", "Group33_COMP306_GroupProject/"]
COPY ["RecipeLibrary/RecipeLibrary.csproj", "RecipeLibrary/"]
RUN dotnet restore "Group33_COMP306_GroupProject/Group33_COMP306_GroupProject.csproj"
COPY . .
WORKDIR "/src/Group33_COMP306_GroupProject"
RUN dotnet build "Group33_COMP306_GroupProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Group33_COMP306_GroupProject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Group33_COMP306_GroupProject.dll"]