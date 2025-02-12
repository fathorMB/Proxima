// tailwind.config.js
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          DEFAULT: 'var(--primary-color)',
          dark: 'var(--primary-dark)' // Add this line
        },
        secondary: 'var(--secondary-color)',
        accent: 'var(--accent-color)',
        success: 'var(--success-color)',
        error: 'var(--error-color)',
        background: 'var(--background-color)',
        text: 'var(--text-color)',
      },
      fontFamily: {
        sans: ['Inter', 'sans-serif'],
      },
    },
  },
  plugins: [],
}