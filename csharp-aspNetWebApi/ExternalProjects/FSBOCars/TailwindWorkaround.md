### Tailwind Build Fix

#### Problem
`tailwindcss@4.3.3` was installed as a library but **did not expose a CLI `bin`**, so `npx tailwindcss` and `npm run build:css` failed on Windows.

---

#### Solution
Use **PostCSS** to run Tailwind as a plugin. Install `postcss-cli` and the Tailwind PostCSS adapter `@tailwindcss/postcss`, add a PostCSS config, and update the `build:css` script to run PostCSS. This produces `wwwroot/css/output.css` without global installs.

---

#### Commands
```bash
# install required dev dependencies
npm install -D postcss-cli @tailwindcss/postcss

# (only if you hit TLS/CA errors on Windows)
# PowerShell:
$env:NODE_OPTIONS='--use-system-ca'

# build CSS
npm run build:css
```

---

#### package.json scripts
```json
"scripts": {
  "test": "echo \"Error: no test specified\" && exit 1",
  "build:css": "postcss ./wwwroot/css/site.css -o ./wwwroot/css/output.css --env production"
}
```

---

#### Key files and contents

**wwwroot/css/site.css**
```css
@import "tailwindcss";
```

**postcss.config.js**
```js
module.exports = {
  plugins: {
    '@tailwindcss/postcss': {},
    autoprefixer: {}
  }
};
```

---

#### Verification
- **Output file**: `wwwroot/css/output.css` was generated.
- **Contains**: Tailwind header (e.g., `/*! tailwindcss v4.3.3`) and utility classes.
- **Size**: tens of KB (depends on used utilities).

---

#### Notes and recommendations
- Add a watch script for development:
```json
"watch:css": "postcss ./wwwroot/css/site.css -o ./wwwroot/css/output.css --watch"
```
- Link `~/css/output.css` in your layout (`_Layout.cshtml`) and hard-refresh the browser after building.
- Optionally automate `npm run build:css` before .NET builds (MSBuild target or `prebuild` script).