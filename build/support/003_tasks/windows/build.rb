require 'albacore'

namespace :build do
  desc 'compiles the project'
  csc :compile => :init do|csc| 
    csc.compile FileList["source/**/*.cs"].exclude("AssemblyInfo.cs")
    csc.references configatron.all_references
    csc.output = File.join(configatron.artifacts_dir,"#{configatron.project}.specs.dll")
    csc.target = :library
  end

  aspnetcompiler :web do|compile|
    compile.physical_path = "source/app.web.ui"
    compile.target_path = configatron.compiled_web_path
    compile.force = true
  end

  task :stop_iis do
    `taskkill -IM iisexpress.exe`
  end

  task :start_iis => [:stop_iis,:web] do
    system("build/tools/iis_express/iisexpress.exe -config:source/config/applicationhost.config")
  end

  task :rebuild => ["clean","compile"]
end
