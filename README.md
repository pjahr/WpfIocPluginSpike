# Proof of concept: WPF + IoC + Plugins
A proof of concept for a WPF application that can be extended by deploying DLLs in a specific directory.
Extensibility is achieved by providing an API DLL with public interfaces. The application includes implementations of those interfaces using an IoC/DI container ([Castle.Windsor](https://github.com/castleproject/Windsor)).

