# GitHub Actions Workflows

This repository contains two GitHub Actions workflows for managing OpenAPI documentation.

## Workflows

### 1. Generate OpenAPI Documentation (`generate-openapi-docs.yml`)
**Trigger:** When a Pull Request is created or updated to the `develop` branch

**Actions:**
- Builds the Users API project
- Generates OpenAPI specification from the compiled assembly
- Saves the spec to `docs/openapi.yaml`
- Commits the generated file back to the PR branch

### 2. Deploy OpenAPI Documentation (`deploy-openapi-docs.yml`)
**Trigger:** When code is pushed/merged to the `develop` branch (and `docs/openapi.yaml` changes)

**Actions:**
- Copies `docs/openapi.yaml` from this repository
- Pushes it as `openapi/users.yaml` to the [api-docs](https://github.com/sampathkumarkrishnan/api-docs) repository
- Runs `npm run pre-build` and `npm run build` in the target repository
- Commits all changes to the `main` branch of the api-docs repository

## Setup Requirements

### GitHub Token for Cross-Repository Access

The deployment workflow requires a GitHub Personal Access Token (PAT) to push to the `api-docs` repository.

**Steps to set up:**

1. **Create a Personal Access Token:**
   - Go to GitHub Settings ? Developer settings ? Personal access tokens ? Tokens (classic)
   - Click "Generate new token" ? "Generate new token (classic)"
   - Give it a descriptive name (e.g., "API Docs Deployment")
   - Set expiration as needed
   - Select the following scopes:
     - ? `repo` (Full control of private repositories)
   - Click "Generate token" and copy it immediately (you won't see it again)

2. **Add the token as a repository secret:**
   - Go to this repository's Settings ? Secrets and variables ? Actions
   - Click "New repository secret"
   - Name: `API_DOCS_TOKEN`
   - Value: Paste the Personal Access Token you created
   - Click "Add secret"

3. **Verify the target repository:**
   - Ensure the `api-docs` repository exists at `https://github.com/sampathkumarkrishnan/api-docs`
   - Ensure it has a `main` branch
   - Ensure it has a `package.json` with `pre-build` and `build` scripts

## Workflow Diagram

```
???????????????????????????????????????????????????????????????????
?                    Pull Request to develop                       ?
???????????????????????????????????????????????????????????????????
                      ?
                      ?
      ?????????????????????????????????????
      ?  Generate OpenAPI Documentation   ?
      ?  (generate-openapi-docs.yml)      ?
      ?                                   ?
      ?  • Build project                  ?
      ?  • Generate docs/openapi.yaml     ?
      ?  • Commit to PR branch            ?
      ?????????????????????????????????????
                      ?
                      ?
              ?????????????????
              ?  PR Merged    ?
              ?  to develop   ?
              ?????????????????
                      ?
                      ?
      ?????????????????????????????????????
      ?   Deploy OpenAPI Documentation    ?
      ?   (deploy-openapi-docs.yml)       ?
      ?                                   ?
      ?  • Copy to api-docs repo          ?
      ?  • Run npm pre-build & build      ?
      ?  • Commit to main branch          ?
      ?????????????????????????????????????
```

## Testing

### Test the Generate workflow:
1. Create a new branch from `develop`
2. Make changes to any controller
3. Create a Pull Request to `develop`
4. The workflow should run and commit `docs/openapi.yaml` to your PR

### Test the Deploy workflow:
1. Ensure the `API_DOCS_TOKEN` secret is configured
2. Merge a PR to `develop` that includes changes to `docs/openapi.yaml`
3. The workflow should run and deploy to the api-docs repository

## Troubleshooting

### Generate workflow issues:
- **Build fails:** Check that the project compiles locally with `dotnet build`
- **Swagger tool not found:** The workflow installs it as a local tool
- **File not committed:** Check that there are actual changes to commit

### Deploy workflow issues:
- **Authentication failed:** Verify the `API_DOCS_TOKEN` secret is set correctly and has repo access
- **npm commands fail:** Ensure the target repository has valid `package.json` with the required scripts
- **Nothing deployed:** Check if `docs/openapi.yaml` actually changed in the merge

## Maintenance

- Update .NET version in workflows when upgrading the project
- Update Node.js version if the api-docs repository requires a different version
- Regenerate the PAT before it expires
- Update Swashbuckle.AspNetCore.Cli version to match the project's Swashbuckle.AspNetCore version
