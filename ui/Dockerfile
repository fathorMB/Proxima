# Stage 1: Build con Node.js
FROM node:20 AS build
WORKDIR /app

# Copia i file di configurazione e installa le dipendenze
COPY package*.json ./
RUN npm install --force

# Copia il resto del codice e compila il progetto
COPY . .
RUN npm run build --prod

# Stage 2: Distribuzione con Nginx
FROM nginx:alpine
# Copia i file statici compilati nella cartella di default di Nginx
COPY --from=build /app/dist/proxima-ui/browser /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
