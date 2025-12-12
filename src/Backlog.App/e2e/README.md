# Playwright E2E Tests

This directory contains end-to-end tests for the Backlog.App using Playwright.

## Prerequisites

- Node.js (v18 or higher)
- npm

## Installation

Playwright is already included in the project's devDependencies. If you need to install browsers, run:

```bash
npx playwright install
```

## Running Tests

### Run all tests (headless)
```bash
npm run test:e2e
```

### Run tests with UI mode (recommended for development)
```bash
npm run test:e2e:ui
```

### Run tests in headed mode (see the browser)
```bash
npm run test:e2e:headed
```

### View the last test report
```bash
npm run test:e2e:report
```

## Test Structure

- `e2e/` - Contains all E2E test files
- `playwright.config.ts` - Playwright configuration

## Configuration

The tests are configured to:
- Run on Chromium, Firefox, and WebKit browsers
- Automatically start the dev server before running tests
- Capture traces on first retry for debugging
- Take screenshots on failure
- Use `http://localhost:4200` as the base URL

## Writing Tests

Follow the example in `e2e/app.spec.ts`. Use Playwright's best practices:
- Use `page.locator()` for finding elements
- Use `expect()` for assertions
- Keep tests independent and isolated
- Use meaningful test descriptions

## CI/CD Integration

The configuration is optimized for CI environments with:
- Automatic retry on failure
- Serial test execution on CI
- HTML reporter for test results
