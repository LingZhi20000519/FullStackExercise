# Frontend

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.0.5.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

## 笔记

1. .angular文件夹中放的是angular的一些缓存
2. .vscode文件夹中放的是vscode相关的一些配置，比如推荐的VS Code插件，用VS Code运行代码打开的是什么浏览器
3. node_modules文件夹是npm自动存放前端包的
4. public文件夹是angular自带的一个小图标，没什么用
5. src文件夹下面是项目的源代码
6. .editorconfig文件是用来规范项目中文件的格式规范，比如ts或md的格式规范
7. .gitignore文件是使用git的，用来配置哪些文件不用去版本追踪
8. angular.json文件是angular的配置，其中配置项目把index.html作为主页面，调用main.ts和styles.css
9. package-lock.json文件是npm锁定的包
10. package.json文件是npm配置的包
11. README.md文件是项目的文档
12. tsconfig.app.json是用来配置TypeScript相关信息的，例如编译后的输出位置。（项目TS配置）
13. tsconfig.json是用来配置TypeScript相关信息的，例如编码格式。（全局TS配置）
14. tsconfig.spec.json是用来配置TypeScript测试代码相关信息的
