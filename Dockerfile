# Base image
FROM mcr.microsoft.com/azure-sql-edge:latest

# Switch to the root user to ensure we have permissions to create directories
USER root

# Create a directory for the SQL setup script
RUN mkdir -p /usr/src/app

# Copy the SQL script to the container
COPY setup.sql /usr/src/app/setup.sql

# Set permissions for the SQL script and directory
RUN chmod -R 755 /usr/src/app

# Expose the SQL Server port
EXPOSE 1433

# Switch back to the mssql user for running the SQL Server service
USER mssql

# Run SQL Server with the setup script execution command
CMD /bin/sh -c "/opt/mssql/bin/sqlservr & sleep 60s & /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -i /usr/src/app/setup.sql && tail -f /dev/null"

