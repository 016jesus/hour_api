FROM aspnetcore/generator

WORKDIR /app

#creo que es así
CMD [ "dotnet", "build" ]