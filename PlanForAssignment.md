Using ChatGPT I have made a plan for how this assignment will be done in a week:


# 🗓️ 5-dagarsplan för Kubernetes-inlämningen
## 🎯 Övergripande mål

  Inlämningen ska innehålla:

  Beskrivning av Kubernetes-komponenter (arkitekturen)

  Beskrivning av vanliga kind:-objekt och deras relationer

  Hur man administrerar kluster lokalt och i molnet

  En egen app som deployas till ett moln-Kuberneteskluster, med:

  Appdesign

  Kubernetes-manifest

  Säkerhetsdesign

  Deploy-beskrivning

## 🧩 Måndag – Teori och struktur (3–5 h)

  Mål: Grundläggande teori färdig + plan för praktiska delen

  Uppgifter

  Sätt upp projektstruktur

  Skapa Git-repo

  Lägg till mappar:

  /app
  /manifests
  /docs


  Lägg till README.md med kort projektbeskrivning

  Skriv avsnitt 1: Kubernetes-komponenter

  Beskriv Control Plane: API Server, etcd, Controller Manager, Scheduler

  Beskriv Worker Node: Kubelet, Kube-Proxy, Container Runtime

  Förklara kort hur de samverkar

  Lägg gärna till ett enkelt diagram (kan ritas i PowerPoint/Draw.io)

  Skriv avsnitt 2: Kubernetes-objekt (börja)

  Pod, Deployment, ReplicaSet, Service

  Kort YAML-exempel för en Pod och Deployment

### Leverans:
  ✔️ Utkast av avsnitt 1 + halva avsnitt 2 + repo-struktur klar

## ⚙️ Tisdag – Färdigställ teori och börja appen (4–6 h)

  Mål: All teori färdig + appens grund klar

  Uppgifter

  Färdigställ avsnitt 2

  StatefulSet, DaemonSet, ConfigMap, Secret, Ingress, PVC, Namespace, Job/CronJob

  Beskriv hur objekten förhåller sig (t.ex. Deployment → ReplicaSet → Pod)

  Skriv avsnitt 3: Administration av kluster

  Lokalt: minikube, kind, k3s

  Moln: AKS, EKS, GKE

  Kommandon: kubectl, helm, kubectl apply/get/describe/logs

  Förklara hur man hanterar kubeconfig och åtkomst

  Börja utveckla appen

  Välj teknik: t.ex. ASP.NET Core minimal API eller Node.js Express

  Skapa en enkel endpoint / som returnerar “Hello from K8S”

  Testa lokalt

### Leverans:
✔️ Avsnitt 1–3 klara (teori färdig)
✔️ Körbar app lokalt

## 🐳 Onsdag – Container & K8S-manifest (4–6 h)

  Mål: Appen containeriserad och har Kubernetes-manifest

  Uppgifter

  Skapa Dockerfile

  Bygg och testa image lokalt

  docker build -t <user>/my-app .

  docker run -p 8080:80 <user>/my-app

  Skapa Kubernetes-manifest

  namespace.yaml

  deployment.yaml

  service.yaml (LoadBalancer eller NodePort)

  configmap.yaml och secret.yaml (om relevant)

  ingress.yaml (valfritt, beroende på molnleverantör)

  Säkerhetsdesign (utkast)

  RBAC (Role/RoleBinding)

  NetworkPolicy

  Secrets och TLS (cert-hantering eller extern secret store)

### Leverans:
✔️ App containeriserad
✔️ K8S-manifest finns i /manifests
✔️ Första versionen av säkerhetsdesign skriven

## ☁️ Torsdag – Deploy till molnet (4–6 h)

  Mål: Appen kör i ett riktigt molnkluster

  Uppgifter

  Skapa molnkluster

  Välj: Azure AKS, Google GKE eller AWS EKS

  Skapa kluster (använd enklaste möjliga GUI eller CLI-väg)

  Konfigurera kubectl:

  az aks get-credentials --resource-group RG --name MyCluster


  Ladda upp image till registry

  Docker Hub, GitHub Container Registry, Azure Container Registry etc.

  docker push <registry>/my-app:latest

  Deploy appen

  kubectl apply -f manifests/

  Kontrollera:

  kubectl get pods,svc -n my-app
  kubectl logs -l app=my-app -n my-app


  Verifiera körning

  Testa åtkomst via IP/URL

  Spara skärmdumpar för rapporten

### Leverans:
✔️ App kör i molnet
✔️ Screenshots på fungerande pod/service

## 📝 Fredag – Rapport & inlämning (4–6 h)

  Mål: Slutrapport klar och färdig för inlämning

  Uppgifter

  Skriv avsnitt 4: Applikationen

  Beskriv design (komponenter, endpoints, ev. databas)

  Beskriv manifestens struktur (vad varje YAML gör)

  Beskriv säkerhet (RBAC, NetworkPolicy, Secrets)

  Beskriv deployments-process (steg för steg)

  Dokumentera & färdigställ rapport

  Inledning, syfte, resultat, slutsats

  Lägg in kodexempel och skärmdumpar

  Exportera till PDF eller DOCX

  Kvalitetskontroll

  Läs igenom allt (stavning, rubriker)

  Kör kubectl get all igen för slutkontroll

  Säkra att README beskriver hur man kör allt

  Lämna in

  Pusha allt till GitHub

  Ladda upp rapporten

### Leverans:
✔️ Rapport klar (PDF eller Word)
✔️ Kod + manifest pushade
✔️ Allt inlämnat

## ✅ Checklista för fredag eftermiddag

   Alla fyra frågeområden täcks i rapporten

   Appen kör i molnet (eller lokalt om fallback)

   Manifestfiler testade med kubectl apply --dry-run=client -f .

   Säkerhetsdesign förklarad

   README tydlig

   Rapport korrekturläst och sparad
