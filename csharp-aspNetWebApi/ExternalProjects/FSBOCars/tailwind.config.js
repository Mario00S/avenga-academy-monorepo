/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./Views/**/*.cshtml",    // MVC views
        "./Areas/**/*.cshtml",    // if you use Areas
        "./Pages/**/*.cshtml",    // if you use Razor Pages
        "./wwwroot/**/*.js",      // JS files
        "./wwwroot/**/*.html"     // optional static HTML
    ],
    safelist: [
        "bg-gray-900",
        "bg-gray-800/50",
        "text-white",
        "text-gray-300",
        "hover:bg-white/5"
    ],
    theme: { extend: {} },
    plugins: [],
}
