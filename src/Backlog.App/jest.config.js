module.exports = {
  preset: 'jest-preset-angular',
  setupFilesAfterEnv: ['<rootDir>/setup-jest.ts'],
  testPathIgnorePatterns: ['/node_modules/', '/dist/', '/e2e/', '/src/test.ts'],
  coverageDirectory: 'coverage',
  collectCoverageFrom: [
    'src/**/*.ts',
    '!src/**/*.spec.ts',
    '!src/main.ts',
    '!src/polyfills.ts',
    '!src/test.ts',
    '!src/environments/**'
  ],
  moduleNameMapper: {
    '^@core$': '<rootDir>/src/app/@core',
    '^@core/(.*)$': '<rootDir>/src/app/@core/$1',
    '^@shared$': '<rootDir>/src/app/@shared',
    '^@shared/(.*)$': '<rootDir>/src/app/@shared/$1',
    '^@api$': '<rootDir>/src/app/@api',
    '^@api/(.*)$': '<rootDir>/src/app/@api/$1'
  },
  transformIgnorePatterns: ['node_modules/(?!.*\\.mjs$)'],
  testMatch: ['**/*.spec.ts']
};
