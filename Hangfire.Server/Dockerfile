FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
# /app directory is the where the binary files are will be present
WORKDIR /app

# Start to build
FROM microsoft/dotnet:2.2-sdk AS build
 
# Copy all source files to /src folder
# This is necessary for solutions. (Multiple projects, also you can define this by specifying projects)
COPY ./ /src
WORKDIR /src

RUN dotnet restore "Hangfire.Server/Hangfire.Server.csproj"
RUN dotnet build "Hangfire.Server/Hangfire.Server.csproj" -c Release -o /app

# Rename the image as publish
FROM build AS publish
RUN dotnet publish "Hangfire.Server/Hangfire.Server.csproj" -c Release -o /out

# Building the project is done. We need the runtime image.
FROM base

# Go back to /app
WORKDIR /app

# Copy all published files into /app folder
COPY --from=publish /out .
ENTRYPOINT ["dotnet", "Hangfire.Server.dll"]