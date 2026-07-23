# Git HOL 2: Git Ignore

## Objectives
- Explain git ignore
- Ignore unwanted files and folders using .gitignore

## Scenario
Create a .log file and a log folder in working directory.
Update .gitignore so that .log files and log folders are ignored on commit.

## Step 1: Create .log file and log folder
echo "This is a log file" > error.log
mkdir logs
echo "log content" > logs\app.log

## Step 2: Check Git Status (log files visible)
git status

## Step 3: Create .gitignore file
echo "*.log" > .gitignore
echo "logs/" >> .gitignore

## Step 4: Verify .gitignore content
cat .gitignore

## Step 5: Check Git Status Again (log files ignored)
git status

## Step 6: Add and Commit .gitignore
git add .gitignore
git commit -m "Add .gitignore to ignore log files and folders"

## Step 7: Verify in Remote Repository
git push origin main

## Expected Output
- .log files should NOT appear in git status
- logs/ folder should NOT appear in git status
- Only .gitignore should be tracked

## Key Concepts
- .gitignore   — File that tells Git which files to ignore
- *.log        — Wildcard to ignore all .log files
- logs/        — Ignore entire logs folder
- git status   — Verify ignored files not tracked