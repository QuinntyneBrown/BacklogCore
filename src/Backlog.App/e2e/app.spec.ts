import { test, expect } from '@playwright/test';

test.describe('Backlog App', () => {
  test('should load the application successfully', async ({ page }) => {
    // Navigate to the app
    await page.goto('/');

    // Wait for the page to be fully loaded
    await page.waitForLoadState('networkidle');

    // Verify the page loaded by checking if the page is visible
    await expect(page.locator('body')).toBeVisible();

    // Take a screenshot for documentation
    await page.screenshot({ path: 'e2e/screenshots/app-loaded.png', fullPage: true });
  });
});
