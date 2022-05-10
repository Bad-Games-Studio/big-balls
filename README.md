# Big Balls

~~There is one (1.00) ball though.~~

This Unity demo shows the application of two major OOP strategies:
  - **Model-View-Presenter** approach for UI and logic decoupling.
  - **Dependency Injection** with the [Zenject](https://github.com/modesttree/Zenject) framework.

## Demo scene

The initial requirements for a demo scene:
  - A red ball that has a health value.
  - A blue box (you can move it with mouse in scene view).
  - On collision with a box, a ball loses one health point.
  - The health is always displayed on screen.

Read about the implementation details below.

![big-balls-demo](https://user-images.githubusercontent.com/49134679/164314139-d72813fd-7115-4417-9364-bbca62546dce.png)


## Model-View-Presenter

This idea is that there are three components:
  - **View** - a component that displays UI.
  - **Model** - an actual data storage that can implement various mechanics. Not visible.
  - **Presenter** - an object that exchanges data between View and Model.

This resembles some sort of a wild combination of Observer and Mediator patterns.

The demo scene has several components.

`BallView` is a class that displays text directly by adjusting the value of `Text` object.
For the sake of demonstration, it also checks for collisions.
It has an event that notifies listeners about collision, and it can accept a new health value to display.

`BallModel` is some sort of inner logic hidden deep in the engine. It can notify listeners about new health values. It also has a method that applies damage to an object (i.e. reduces health).

`BallPresenter` effectively listens for events from a `BallView` and then notifies `BallModel`, and vice versa.

Thus, the order of calls is: `View -> Presenter -> Model -> Presenter -> View`.

Note that `BallModel` knows nothing about two other components. `BallView` doesn't know anything either. This means they've been successfully decoupled.

Also note that `BallModel` and `BallPresenter` have to be created somewhere manually.

## Dependency Injection

To allow for even more loose coupling, we can apply dependency injection principle for `BallPresenter`. This allows to replace models and views with any others that fit the requirement.

`BallInjection` is a class that inherits `Zenject` injector `MonoInstaller`, and is used in `SceneContext` Game Object (see object hierarchy).
What this object does is instantiating each dependency and injecting them in constructors (when possible) or methods.
