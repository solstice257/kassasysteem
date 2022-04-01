FROM node:14-alpine

WORKDIR /usr/src/app

COPY Frontend/rollup.config.js ./
COPY Frontend/package*.json ./

RUN npm install

COPY ./src ./src
COPY ./public ./public

RUN npm run-script build

EXPOSE 5000

ENV HOST=0.0.0.0

CMD [ "npm", "start" ]