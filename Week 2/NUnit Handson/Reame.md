# Notes - Unit Testing with NUnit

## What is Unit Testing

Unit testing means testing the smallest piece of code that can be tested on
its own, usually a single method or function, completely isolated from
everything else. If that method needs other things (a database, another
class, an API call), those get faked/mocked so the test only checks the
logic inside that one method, not whether the rest of the system works.

## Unit Testing vs Functional Testing

Unit testing checks one small piece in isolation. Functional testing checks
a whole feature or flow end to end, the way a real user would use it,
including all the pieces working together (UI, business logic, database,
etc).

Unit tests are fast and pinpoint exactly which method broke. Functional
tests are slower but catch issues that only show up when components
interact with each other.

## Types of Testing

- Unit testing - smallest testable piece, isolated
- Functional testing - tests a feature/flow as a whole
- Automated testing - tests run by a tool/script instead of a person
  clicking through manually
- Performance testing - checks speed, load handling, response time under
  stress

## Benefit of Automated Testing

Once written, automated tests can run in seconds, as many times as needed,
without a person needing to manually click through the app again. This
matters a lot when code changes - instead of manually re-checking
everything still works, you just run the test suite and instantly know if
something broke.

## Loosely Coupled & Testable Design

A class is loosely coupled when it doesn't directly depend on things outside
itself to do its job - no hardcoded database calls, no creating other
classes internally that it then can't swap out. The Calculator class in this
exercise is a simple example - it just takes numbers as parameters and
returns a number, nothing else, so there's nothing to fake or set up before
testing it.

If a class internally creates and uses another class on its own (like
calling `new SqlConnection()` directly inside a method), it becomes harder
to test because you can't easily replace that dependency with a fake version
during a test. That's where dependency injection and mocking come in later.

## SetUp, TearDown and Ignore

- [SetUp] runs before every single test method in the class. Used to create
  a fresh object so each test starts clean and tests don't affect each other.
- [TearDown] runs after every test method. Used for cleanup, closing
  connections, releasing resources, etc.
- [Ignore("reason")] skips a test without deleting it. Shows up as "skipped"
  in the test results instead of pass/fail. Useful for tests that are
  temporarily broken or not relevant yet.

## Why Parameterised Tests (TestCase) Are Useful

Without TestCase, testing the same method with 5 different inputs means
writing 5 separate test methods that all look almost identical except for
the numbers. TestCase lets you write the method once and just list out all
the input/expected-output combinations above it. Less duplicate code, and
adding a new test case is just adding one more line instead of a whole new
method.